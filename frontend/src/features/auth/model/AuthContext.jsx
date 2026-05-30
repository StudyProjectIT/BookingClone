import { createContext, useContext, useEffect, useMemo, useState } from 'react';
import { tokenStorage, userStorage } from '@shared/lib/tokenStorage';
import { userApi } from '@entities/user';
import { authApi } from '../api/authApi';

const AuthContext = createContext(null);

export function AuthProvider({ children }) {
  const [user, setUser] = useState(() => userStorage.get());
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const token = tokenStorage.get();
    if (token && !user) {
      setLoading(true);
      userApi.me()
        .then((u) => {
          setUser(u);
          userStorage.set(u);
        })
        .catch(() => {
          tokenStorage.clear();
          setUser(null);
        })
        .finally(() => setLoading(false));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const applyAuthResponse = (data) => {
    tokenStorage.set(data.token);
    userStorage.set(data.user);
    setUser(data.user);
  };

  const login = async (dto) => {
    const data = await authApi.login(dto);
    applyAuthResponse(data);
  };

  const register = async (dto) => {
    const data = await authApi.register(dto);
    applyAuthResponse(data);
  };

  const updateProfile = async (dto) => {
    const data = await authApi.updateProfile(dto);
    applyAuthResponse(data);
  };

  const logout = () => {
    tokenStorage.clear();
    setUser(null);
  };

  const value = useMemo(
    () => ({ user, isAuthenticated: !!user, loading, login, register, updateProfile, logout }),
    [user, loading],
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error('useAuth must be used inside <AuthProvider>');
  return ctx;
}
