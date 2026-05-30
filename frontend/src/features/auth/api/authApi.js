import { httpClient } from '@shared/api/httpClient';

export const authApi = {
  register: (dto) => httpClient.post('/auth/register', dto).then((r) => r.data),
  login: (dto) => httpClient.post('/auth/login', dto).then((r) => r.data),
  updateProfile: (dto) => httpClient.patch('/auth/profile', dto).then((r) => r.data),
};
