import { useNavigate, Link } from 'react-router-dom';
import { LoginForm } from '@features/auth';

export function LoginPage() {
  const navigate = useNavigate();
  return (
    <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
      <LoginForm onSuccess={() => navigate('/hotels')} />
      <p style={{ marginTop: 8 }}>
        <Link to="/forgot-password">Forgot password?</Link>
      </p>
      <p style={{ marginTop: 4 }}>
        No account? <Link to="/register">Create one</Link>.
      </p>
    </section>
  );
}
