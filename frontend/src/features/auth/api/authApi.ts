import { httpClient } from '@shared/api/httpClient';
import type { AuthResponse } from '@shared/types';

export interface LoginDto {
  emailOrUserName: string;
  password: string;
}

export interface RegisterDto {
  email: string;
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
}

export interface UpdateProfileDto {
  email: string;
  userName: string;
  firstName: string;
  lastName: string;
}

export const authApi = {
  register: (dto: RegisterDto): Promise<AuthResponse> =>
    httpClient.post<AuthResponse>('/auth/register', dto).then((r) => r.data),

  login: (dto: LoginDto): Promise<AuthResponse> =>
    httpClient.post<AuthResponse>('/auth/login', dto).then((r) => r.data),

  updateProfile: (dto: UpdateProfileDto): Promise<AuthResponse> =>
    httpClient.patch<AuthResponse>('/auth/profile', dto).then((r) => r.data),
};
