import { httpClient } from '@shared/api/httpClient';
import type { User } from '@shared/types';

export const userApi = {
  me: (): Promise<User> => httpClient.get<User>('/auth/me').then((r) => r.data),
};
