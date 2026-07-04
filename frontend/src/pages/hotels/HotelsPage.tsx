import { useEffect, useState } from 'react';
import { hotelApi, HotelCard } from '@entities/hotel';
import type { Hotel } from '@shared/types';

export function HotelsPage() {
  const [hotels, setHotels] = useState<Hotel[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    hotelApi.getAll()
      .then(setHotels)
      .catch((err: unknown) => {
        const axiosErr = err as { response?: { data?: { error?: string } }; message?: string };
        setError(axiosErr.response?.data?.error ?? axiosErr.message ?? 'Failed to load hotels');
      })
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
