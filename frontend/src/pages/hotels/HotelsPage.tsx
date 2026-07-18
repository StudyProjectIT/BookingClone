import { useEffect, useState } from 'react';
import { hotelApi, HotelCard } from '@entities/hotel';
import type { Hotel } from '@shared/types';

const PAGE_SIZE = 10;

export function HotelsPage() {
  const [hotels, setHotels] = useState<Hotel[]>([]);
  const [total, setTotal] = useState(0);
  const [page, setPage] = useState(1);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    setLoading(true);
    setError(null);
    hotelApi.getAllPaged({ page, pageSize: PAGE_SIZE })
      .then(({ items, totalCount }) => {
        setHotels(items);
        setTotal(totalCount);
      })
      .catch((err: unknown) => {
        const axiosErr = err as { response?: { data?: { error?: string } }; message?: string };
        setError(axiosErr.response?.data?.error ?? axiosErr.message ?? 'Failed to load hotels');
      })
      .finally(() => setLoading(false));
  }, [page]);

  const totalPages = Math.ceil(total / PAGE_SIZE);

  return (
    <section style={{ padding: 24, maxWidth: 720, margin: '0 auto' }}>
      <h1>Hotels</h1>

      {loading && <p>Loading…</p>}
      {error && <p style={{ color: 'crimson' }}>{error}</p>}
      {!loading && !error && hotels.length === 0 && <p>No hotels yet.</p>}

      {hotels.map((h) => <HotelCard key={h.id} hotel={h} />)}

      {totalPages > 1 && (
        <div style={{ display: 'flex', gap: 8, justifyContent: 'center', marginTop: 24, alignItems: 'center' }}>
          <button
            onClick={() => setPage((p) => p - 1)}
            disabled={page === 1 || loading}
            style={{ padding: '6px 14px', cursor: 'pointer' }}
          >
            ← Prev
          </button>
          <span style={{ color: 'var(--text)' }}>
            Page {page} of {totalPages} ({total} hotels)
          </span>
          <button
            onClick={() => setPage((p) => p + 1)}
            disabled={page >= totalPages || loading}
            style={{ padding: '6px 14px', cursor: 'pointer' }}
          >
            Next →
          </button>
        </div>
      )}
    </section>
  );
}
