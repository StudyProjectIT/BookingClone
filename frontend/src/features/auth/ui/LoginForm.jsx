import { useState } from 'react';
import { useAuth } from '../model/AuthContext';

export function LoginForm({ onSuccess }) {
  const { login } = useAuth();
  const [form, setForm] = useState({ emailOrUserName: '', password: '' });
  const [error, setError] = useState(null);
  const [busy, setBusy] = useState(false);

  const onSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setBusy(true);
    try {
      await login(form);
      onSuccess?.();
    } catch (err) {
      setError(err.response?.data?.error ?? 'Login failed');
    } finally {
      setBusy(false);
    }
  };

  return (
    <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8, maxWidth: 320 }}>
      <h2>Sign in</h2>
      <input
        placeholder="Email or username"
        value={form.emailOrUserName}
        onChange={(e) => setForm({ ...form, emailOrUserName: e.target.value })}
        required
      />
      <input
        type="password"
        placeholder="Password"
        value={form.password}
        onChange={(e) => setForm({ ...form, password: e.target.value })}
        required
      />
      {error && <div style={{ color: 'crimson' }}>{error}</div>}
      <button type="submit" disabled={busy}>{busy ? '...' : 'Sign in'}</button>
    </form>
  );
}
