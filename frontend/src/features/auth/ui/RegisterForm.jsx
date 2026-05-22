import { useState } from 'react';
import { useAuth } from '../model/AuthContext';

const initial = { email: '', userName: '', password: '', firstName: '', lastName: '' };

export function RegisterForm({ onSuccess }) {
  const { register } = useAuth();
  const [form, setForm] = useState(initial);
  const [error, setError] = useState(null);
  const [busy, setBusy] = useState(false);

  const onSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setBusy(true);
    try {
      await register(form);
      onSuccess?.();
    } catch (err) {
      setError(err.response?.data?.error ?? 'Registration failed');
    } finally {
      setBusy(false);
    }
  };

  const upd = (k) => (e) => setForm({ ...form, [k]: e.target.value });

  return (
    <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8, maxWidth: 320 }}>
      <h2>Create account</h2>
      <input placeholder="Email" type="email" value={form.email} onChange={upd('email')} required />
      <input placeholder="Username" value={form.userName} onChange={upd('userName')} required minLength={3} />
      <input placeholder="First name" value={form.firstName} onChange={upd('firstName')} required />
      <input placeholder="Last name" value={form.lastName} onChange={upd('lastName')} required />
      <input placeholder="Password" type="password" value={form.password} onChange={upd('password')} required minLength={8} />
      {error && <div style={{ color: 'crimson' }}>{error}</div>}
      <button type="submit" disabled={busy}>{busy ? '...' : 'Register'}</button>
    </form>
  );
}
