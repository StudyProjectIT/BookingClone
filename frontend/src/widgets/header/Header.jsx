import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '@features/auth';

export function Header() {
  const { user, isAuthenticated, logout } = useAuth();
  const navigate = useNavigate();

  return (
    <header style={{
      display: 'flex',
      gap: 16,
      alignItems: 'center',
      padding: '12px 24px',
      borderBottom: '1px solid #eee',
    }}>
      <Link to="/" style={{ fontWeight: 700, textDecoration: 'none', color: 'inherit' }}>
        BookingClone
      </Link>
      <Link to="/hotels">Hotels</Link>
      <div style={{ marginLeft: 'auto', display: 'flex', gap: 12 }}>
        {isAuthenticated ? (
          <>
            <span>Hi, {user.userName}</span>
            <button onClick={() => { logout(); navigate('/'); }}>Sign out</button>
          </>
        ) : (
          <>
            <Link to="/login">Sign in</Link>
            <Link to="/register">Register</Link>
          </>
        )}
      </div>
    </header>
  );
}
