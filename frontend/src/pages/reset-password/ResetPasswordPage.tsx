import { useState } from 'react';
import type { FormEvent } from 'react';
import { useSearchParams, Link } from 'react-router-dom';
import { authApi } from '@features/auth/api/authApi';

export function ResetPasswordPage() {
  const [params] = useSearchParams();
  const email = params.get('email') ?? '';
  const token = params.get('token') ?? '';

  const [newPassword, setNewPassword] = useState('');
  const [confirm, setConfirm] = useState('');
  const [message, setMessage] = useState<string | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [busy, setBusy] = useState(false);

  if (!email || !token) {
    return (
      <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
        <div style={{ padding: 16, background: '#fef2f2', border: '1px solid #fca5a5', borderRadius: 8 }}>
          Invalid or expired reset link.
        </div>
        <p style={{ marginTop: 12 }}>
          <Link to="/forgot-password">Request a new one</Link>
        </p>
      </section>
    );
  }

  const onSubmit = async (e: FormEvent) => {
    e.preventDefault();
    if (newPassword !== confirm) {
      setError('Passwords do not match.');
      return;
    }
    setError(null);
    setBusy(true);
    try {
      const msg = await authApi.resetPassword(email, token, newPassword);
      setMessage(msg);
    } catch (err: unknown) {
      const axiosErr = err as { response?: { data?: { error?: string } } };
      setError(axiosErr.response?.data?.error ?? 'Reset failed. The link may have expired.');
    } finally {
      setBusy(false);
    }
  };

  if (message) {
    return (
      <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
        <div style={{ padding: 16, background: '#f0fdf4', border: '1px solid #86efac', borderRadius: 8 }}>
          {message}
        </div>
        <p style={{ marginTop: 12 }}>
          <Link to="/login">Sign in</Link>
        </p>
      </section>
    );
  }

  return (
    <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
      <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8 }}>
        <h2>Reset password</h2>
        <input
          type="password"
          placeholder="New password"
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
          required
          minLength={8}
        />
        <input
          type="password"
          placeholder="Confirm new password"
          value={confirm}
          onChange={(e) => setConfirm(e.target.value)}
          required
          minLength={8}
        />
        {error && <div style={{ color: 'crimson' }}>{error}</div>}
        <button type="submit" disabled={busy}>{busy ? '…' : 'Reset password'}</button>
      </form>
    </section>
  );
}
