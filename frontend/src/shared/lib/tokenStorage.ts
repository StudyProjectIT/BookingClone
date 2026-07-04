import type { User } from '@shared/types';
import { TOKEN_STORAGE_KEY, REFRESH_TOKEN_STORAGE_KEY, USER_STORAGE_KEY } from '@shared/config/env';

export const tokenStorage = {
  get: (): string | null => localStorage.getItem(TOKEN_STORAGE_KEY),
  set: (token: string): void => { localStorage.setItem(TOKEN_STORAGE_KEY, token); },
  clear: (): void => {
    localStorage.removeItem(TOKEN_STORAGE_KEY);
    localStorage.removeItem(REFRESH_TOKEN_STORAGE_KEY);
    localStorage.removeItem(USER_STORAGE_KEY);
  },
};

export const refreshTokenStorage = {
  get: (): string | null => localStorage.getItem(REFRESH_TOKEN_STORAGE_KEY),
  set: (token: string): void => { localStorage.setItem(REFRESH_TOKEN_STORAGE_KEY, token); },
};

export const userStorage = {
  get: (): User | null => {
    const raw = localStorage.getItem(USER_STORAGE_KEY);
    return raw ? (JSON.parse(raw) as User) : null;
  },
  set: (user: User): void => { localStorage.setItem(USER_STORAGE_KEY, JSON.stringify(user)); },
};
