import { useEffect, useState } from 'react';
import { hotelApi, HotelCard } from '@entities/hotel';

export function HotelsPage() {
  const [hotels, setHotels] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    hotelApi.getAll()
      .then(setHotels)
      .catch((err) => setError(err.response?.data?.error ?? err.message))
      .finally(() => setLoading(false));
  }, []);

  return (
    <section style={{ padding: 24, maxWidth: 720, margin: '0 auto' }}>
      <h1>Hotels</h1>
      {loading && <p>Loading…</p>}
      {error && <p style={{ color: 'crimson' }}>{error}</p>}
      {!loading && !error && hotels.length === 0 && <p>No hotels yet.</p>}
      {hotels.map((h) => <HotelCard key={h.id} hotel={h} />)}
    </section>
  );
}
