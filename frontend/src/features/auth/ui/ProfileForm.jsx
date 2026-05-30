import { useState } from 'react';
import { useAuth } from '../model/AuthContext';

export function ProfileForm({ onSuccess }) {
  const { updateProfile } = useAuth();
  const [form, setForm] = useState(useAuth().user);
  const [error, setError] = useState(null);
  const [busy, setBusy] = useState(false);

  const onSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setBusy(true);
    try {
      await updateProfile(form);
      onSuccess?.();
    } catch (err) {
      setError(err.response?.data?.error ?? 'Failed to update user profile');
      console.log(err);
    } finally {
      setBusy(false);
    }
  };

  const upd = (k) => (e) => setForm({ ...form, [k]: e.target.value });

  // TODO: in the future we will need to let the user change the password
  return (
    <form onSubmit={onSubmit} style={{ display: 'grid', gap: 8, maxWidth: 320 }}>
      <h2>Update profile</h2>
      <input placeholder="Email" type="email" value={form.email} onChange={upd('email')} required />
      <input placeholder="Username" value={form.userName} onChange={upd('userName')} required minLength={3} />
      <input placeholder="First name" value={form.firstName} onChange={upd('firstName')} required />
      <input placeholder="Last name" value={form.lastName} onChange={upd('lastName')} required />
      {error && <div style={{ color: 'crimson' }}>{error}</div>}
      <button type="submit" disabled={busy}>{busy ? '...' : 'Update'}</button>
    </form>
  );
}

