import { useAuth } from '@features/auth';
import { Navigate } from 'react-router';
import { ProfileForm } from '@features/auth';

export function ProfilePage() {
  let auth = useAuth();
  if (!auth.isAuthenticated) return <Navigate to="/login" />

  return <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
    <ProfileForm onSuccess={() => navigate('/hotels')} />
  </section>;
}
