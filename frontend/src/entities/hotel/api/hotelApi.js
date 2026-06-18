import { httpClient } from '@shared/api/httpClient';

export const hotelApi = {
  getAll: () => httpClient.get('/hotels').then((r) => r.data.items ?? r.data),
  getById: (id) => httpClient.get(`/hotels/${id}`).then((r) => r.data),
  create: (dto) => httpClient.post('/hotels', dto).then((r) => r.data),
  update: (id, dto) => httpClient.put(`/hotels/${id}`, dto),
  remove: (id) => httpClient.delete(`/hotels/${id}`),
};
