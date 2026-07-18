import { useState } from 'react';
import { Link } from 'react-router-dom';
import { RegisterForm } from '@features/auth';

export function RegisterPage() {
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  if (successMessage) {
    return (
      <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
        <div style={{ padding: 16, background: '#f0fdf4', border: '1px solid #86efac', borderRadius: 8 }}>
          <strong>Almost there!</strong>
          <p style={{ margin: '8px 0 0' }}>{successMessage}</p>
        </div>
        <p style={{ marginTop: 12 }}>
          Didn't receive it? <Link to="/resend-confirmation">Resend confirmation email</Link>.
        </p>
      </section>
    );
  }

  return (
    <section style={{ padding: 24, maxWidth: 360, margin: '0 auto' }}>
      <RegisterForm onSuccess={(msg) => setSuccessMessage(msg)} />
      <p style={{ marginTop: 12 }}>
        Already have an account? <Link to="/login">Sign in</Link>.
      </p>
    </section>
  );
}
