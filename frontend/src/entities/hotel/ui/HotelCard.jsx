export function HotelCard({ hotel }) {
  return (
    <article style={{
      border: '1px solid #ddd',
      borderRadius: 8,
      padding: 16,
      marginBottom: 12,
    }}>
      <h3 style={{ margin: '0 0 8px' }}>{hotel.name}</h3>
      {hotel.location && <p style={{ margin: '0 0 4px', color: '#666' }}>{hotel.location}</p>}
      {hotel.description && <p style={{ margin: '0 0 8px' }}>{hotel.description}</p>}
      {hotel.pricePerNight > 0 && (
        <strong>${hotel.pricePerNight} / night</strong>
      )}
    </article>
  );
}
