import { useState } from 'react';
import type { FormEvent } from 'react';
import { Link } from 'react-router-dom';
import { authApi } from '@features/auth/api/authApi';

export function ResendConfirmationPage() {
  const [email, setEmail] = useState('');
  const [message, setMessage] = useState<string | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [busy, setBusy] = useState(false);

  const onSubmit = async (e: FormEvent) => {
    e.preventDefault();
    setError(null);
    setBusy(true);
    try {
      const msg = await authApi.resendConfirmation(email);
      setMessage(msg);
    } catch (err: unknown) {
      const axiosErr = err as { response?: { data?: { error?: string } } };
      setError(axiosErr.response?.data?.error ?? 'Something went wrong. Please try again.');
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
          <Link to="/login">Back to sign in</Link>
        </p>
      </section>
    );
  }

  return (
    <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
      <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8 }}>
        <h2>Resend confirmation email</h2>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
        {error && <div style={{ color: 'crimson' }}>{error}</div>}
        <button type="submit" disabled={busy}>{busy ? '…' : 'Resend'}</button>
      </form>
      <p style={{ marginTop: 12 }}>
        <Link to="/login">Back to sign in</Link>
      </p>
    </section>
  );
}
