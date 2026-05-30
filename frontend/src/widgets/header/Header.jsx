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
          <Link to="/profile">
            <img style={{ marginRight: "0.5em", display: 'inline', height: '1.2em', width: 'auto' }} src="/user-icon.svg" />
            {user.userName}
          </Link>
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
