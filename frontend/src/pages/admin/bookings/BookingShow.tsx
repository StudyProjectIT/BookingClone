import { Show, TextField, DateField, NumberField } from '@refinedev/antd';
import { useShow } from '@refinedev/core';
import { Typography, Tag } from 'antd';
import type { BookingStatus } from '@shared/types';

const { Title } = Typography;

const statusColor: Record<BookingStatus, string> = {
  Pending: 'orange',
  Confirmed: 'green',
  Cancelled: 'red',
  Completed: 'blue',
};

export function BookingShow() {
  const { query } = useShow();
  const { data, isLoading } = query;
  const record = data?.data as { id: number; hotelId: number; checkIn: string; checkOut: string; totalPrice: number; status: BookingStatus } | undefined;

  return (
    <Show isLoading={isLoading}>
      <Title level={5}>ID</Title>
      <TextField value={record?.id} />

      <Title level={5}>Hotel ID</Title>
      <TextField value={record?.hotelId} />

      <Title level={5}>Check In</Title>
      <DateField value={record?.checkIn} />

      <Title level={5}>Check Out</Title>
      <DateField value={record?.checkOut} />

      <Title level={5}>Total Price</Title>
      <NumberField value={record?.totalPrice ?? 0} options={{ style: 'currency', currency: 'USD' }} />

      <Title level={5}>Status</Title>
      {record?.status && <Tag color={statusColor[record.status]}>{record.status}</Tag>}
    </Show>
  );
}
