import type { AuthProvider } from '@refinedev/core';
import { tokenStorage, userStorage } from '@shared/lib/tokenStorage';
import { httpClient } from './httpClient';
import type { AuthResponse } from '@shared/types';

export const authProvider: AuthProvider = {
  login: async ({ email, password }: { email: string; password: string }) => {
    try {
      const { data } = await httpClient.post<AuthResponse>('/auth/login', {
        emailOrUserName: email,
        password,
      });
      tokenStorage.set(data.token);
      userStorage.set(data.user);
      return { success: true, redirectTo: '/admin' };
    } catch {
      return {
        success: false,
        error: { name: 'Login Error', message: 'Invalid credentials' },
      };
    }
  },

  logout: async () => {
    tokenStorage.clear();
    return { success: true, redirectTo: '/admin/login' };
  },

  check: async () => {
    const token = tokenStorage.get();
    if (!token) return { authenticated: false, redirectTo: '/admin/login' };
    const user = userStorage.get();
    if (!user?.roles?.includes('Admin')) {
      return {
        authenticated: false,
        redirectTo: '/admin/login',
        error: { name: 'Access Denied', message: 'Admin role required' },
      };
    }
    return { authenticated: true };
  },

  getPermissions: async () => {
    const user = userStorage.get();
    return user?.roles ?? [];
  },

  getIdentity: async () => {
    const user = userStorage.get();
    if (!user) return null;
    return {
      id: user.id,
      name: `${user.firstName} ${user.lastName}`,
      email: user.email,
      avatar: null,
    };
  },

  onError: async (error: unknown) => {
    if (error && typeof error === 'object' && 'response' in error) {
      const e = error as { response?: { status?: number } };
      if (e.response?.status === 401) return { logout: true };
    }
    return { error: error as Error };
  },
};
