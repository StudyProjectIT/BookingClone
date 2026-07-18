import { useEffect, useState } from 'react';
import { useSearchParams, Link } from 'react-router-dom';
import { authApi } from '@features/auth/api/authApi';

type Status = 'loading' | 'success' | 'error';

export function ConfirmEmailPage() {
  const [params] = useSearchParams();
  const [status, setStatus] = useState<Status>('loading');
  const [message, setMessage] = useState('');

  useEffect(() => {
    const userId = Number(params.get('userId'));
    const token = params.get('token') ?? '';

    if (!userId || !token) {
      setMessage('Invalid confirmation link.');
      setStatus('error');
      return;
    }

    authApi.confirmEmail(userId, token)
      .then((msg) => { setMessage(msg); setStatus('success'); })
      .catch((err: unknown) => {
        const axiosErr = err as { response?: { data?: { error?: string } } };
        setMessage(axiosErr.response?.data?.error ?? 'Confirmation failed. The link may have expired.');
        setStatus('error');
      });
  }, [params]);

  return (
    <section style={{ padding: 24, maxWidth: 400, margin: '0 auto' }}>
      <h2>Email confirmation</h2>
      {status === 'loading' && <p>Confirming your email…</p>}
      {status === 'success' && (
        <>
          <div style={{ padding: 16, background: '#f0fdf4', border: '1px solid #86efac', borderRadius: 8 }}>
            {message}
          </div>
          <p style={{ marginTop: 12 }}>
            <Link to="/login">Sign in</Link>
          </p>
        </>
      )}
      {status === 'error' && (
        <>
          <div style={{ padding: 16, background: '#fef2f2', border: '1px solid #fca5a5', borderRadius: 8 }}>
            {message}
          </div>
          <p style={{ marginTop: 12 }}>
            <Link to="/resend-confirmation">Resend confirmation email</Link>
          </p>
        </>
      )}
    </section>
  );
}
