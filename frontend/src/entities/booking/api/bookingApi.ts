import { httpClient } from '@shared/api/httpClient';
import type { Booking, BookingStatus, PagedResult } from '@shared/types';

export interface CreateBookingDto {
  roomVariantId: number;
  quantity: number;
  checkIn: string;
  checkOut: string;
  totalPrice: number;
  personalWishes?: string;
}

export const bookingApi = {
  getAll: (): Promise<PagedResult<Booking>> =>
    httpClient.get<PagedResult<Booking>>('/bookings').then((r) => r.data),

  getById: (id: number): Promise<Booking> =>
    httpClient.get<Booking>(`/bookings/${id}`).then((r) => r.data),

  create: (dto: CreateBookingDto): Promise<Booking> =>
    httpClient.post<Booking>('/bookings', dto).then((r) => r.data),

  update: (id: number, dto: CreateBookingDto): Promise<void> =>
    httpClient.put(`/bookings/${id}`, dto).then(() => undefined),

  changeStatus: (id: number, status: BookingStatus): Promise<Booking> =>
    httpClient.patch<Booking>(`/bookings/${id}/status`, { status }).then((r) => r.data),

  remove: (id: number): Promise<void> =>
    httpClient.delete(`/bookings/${id}`).then(() => undefined),
};
