import { useNavigate, Link } from 'react-router-dom';
import { RegisterForm } from '@features/auth';

export function RegisterPage() {
  const navigate = useNavigate();
  return (
    <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
      <RegisterForm onSuccess={() => navigate('/hotels')} />
      <p style={{ marginTop: 12 }}>
        Already have an account? <Link to="/login">Sign in</Link>.
      </p>
    </section>
  );
}
