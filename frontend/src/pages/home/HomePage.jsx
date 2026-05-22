import { Link } from 'react-router-dom';

export function HomePage() {
  return (
    <section style={{ padding: 24 }}>
      <h1>Find your next stay</h1>
      <p>Browse hotels and make a booking in a few clicks.</p>
      <Link to="/hotels">Browse hotels →</Link>
    </section>
  );
}
