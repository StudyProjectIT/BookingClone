import { TOKEN_STORAGE_KEY, REFRESH_TOKEN_STORAGE_KEY, USER_STORAGE_KEY } from '@shared/config/env';

export const tokenStorage = {
  get: () => localStorage.getItem(TOKEN_STORAGE_KEY),
  set: (token) => localStorage.setItem(TOKEN_STORAGE_KEY, token),
  clear: () => {
    localStorage.removeItem(TOKEN_STORAGE_KEY);
    localStorage.removeItem(REFRESH_TOKEN_STORAGE_KEY);
    localStorage.removeItem(USER_STORAGE_KEY);
  },
};

export const refreshTokenStorage = {
  get: () => localStorage.getItem(REFRESH_TOKEN_STORAGE_KEY),
  set: (token) => localStorage.setItem(REFRESH_TOKEN_STORAGE_KEY, token),
};

export const userStorage = {
  get: () => {
    const raw = localStorage.getItem(USER_STORAGE_KEY);
    return raw ? JSON.parse(raw) : null;
  },
  set: (user) => localStorage.setItem(USER_STORAGE_KEY, JSON.stringify(user)),
};
