import type { Hotel } from '@shared/types';

interface Props {
  hotel: Hotel;
}

export function HotelCard({ hotel }: Props) {
  return (
    <article style={{
      border: '1px solid var(--border)',
      borderRadius: 8,
      padding: 16,
      marginBottom: 12,
      textAlign: 'left',
    }}>
      <h3 style={{ margin: '0 0 4px' }}>{hotel.name}</h3>
      <p style={{ margin: '0 0 4px', color: 'var(--text)' }}>
        {hotel.cityName}, {hotel.countryName}
      </p>
      {hotel.description && (
        <p style={{ margin: '0 0 8px' }}>{hotel.description}</p>
      )}
      <span style={{ fontSize: 13, color: 'var(--text)' }}>{hotel.hotelCategoryName}</span>
    </article>
  );
}
