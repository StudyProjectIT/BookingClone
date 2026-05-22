import { httpClient } from '@shared/api/httpClient';

export const userApi = {
  me: () => httpClient.get('/auth/me').then((r) => r.data),
};
