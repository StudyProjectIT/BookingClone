import { httpClient } from '@shared/api/httpClient';

export const bookingApi = {
  getAll: () => httpClient.get('/bookings').then((r) => r.data),
  getById: (id) => httpClient.get(`/bookings/${id}`).then((r) => r.data),
  create: (dto) => httpClient.post('/bookings', dto).then((r) => r.data),
  update: (id, dto) => httpClient.put(`/bookings/${id}`, dto),
  remove: (id) => httpClient.delete(`/bookings/${id}`),
};
