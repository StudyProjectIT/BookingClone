import { Show } from '@refinedev/antd';
import { useShow, useUpdate } from '@refinedev/core';
import { Typography, Tag, Button, Space, Divider } from 'antd';
import type { BookingStatus } from '@shared/types';

const { Title, Text } = Typography;

const statusColor: Record<BookingStatus, string> = {
  Pending: 'orange',
  Confirmed: 'green',
  Cancelled: 'red',
  Completed: 'blue',
};

interface BookingRecord {
  id: number;
  hotelId: number;
  userId: string;
  checkIn: string;
  checkOut: string;
  guests: number;
  totalPrice: number;
  status: BookingStatus;
  confirmedAtUtc: string | null;
  cancelledAtUtc: string | null;
}

export function BookingShow() {
  const { query } = useShow();
  const { data, isLoading } = query;
  const record = data?.data as BookingRecord | undefined;
  const { mutate: updateStatus, isLoading: isUpdating = false } = useUpdate() as { mutate: typeof useUpdate extends () => { mutate: infer M } ? M : never; isLoading?: boolean };

  const changeStatus = (status: BookingStatus) => {
    if (!record) return;
    updateStatus({
      resource: 'bookings',
      id: `${record.id}/status`,
      values: { status },
      successNotification: { message: `Status changed to ${status}`, type: 'success' },
    });
  };

  const allowedTransitions: BookingStatus[] = record ? (
    record.status === 'Pending' ? ['Confirmed', 'Cancelled'] :
    record.status === 'Confirmed' ? ['Cancelled', 'Completed'] : []
  ) : [];

  return (
    <Show isLoading={isLoading}>
      <Title level={5}>ID</Title>
      <Text>{record?.id}</Text>

      <Title level={5}>Customer</Title>
      <Text>{record?.userId}</Text>

      <Title level={5}>Check In</Title>
      <Text>{record?.checkIn ? new Date(record.checkIn).toLocaleDateString() : '—'}</Text>

      <Title level={5}>Check Out</Title>
      <Text>{record?.checkOut ? new Date(record.checkOut).toLocaleDateString() : '—'}</Text>

      <Title level={5}>Guests</Title>
      <Text>{record?.guests}</Text>

      <Title level={5}>Total Price</Title>
      <Text>${record?.totalPrice?.toFixed(2)}</Text>

      <Title level={5}>Status</Title>
      {record?.status && <Tag color={statusColor[record.status]}>{record.status}</Tag>}

      {record?.confirmedAtUtc && (
        <>
          <Title level={5}>Confirmed At</Title>
          <Text>{new Date(record.confirmedAtUtc).toLocaleString()}</Text>
        </>
      )}
      {record?.cancelledAtUtc && (
        <>
          <Title level={5}>Cancelled At</Title>
          <Text>{new Date(record.cancelledAtUtc).toLocaleString()}</Text>
        </>
      )}

      {allowedTransitions.length > 0 && (
        <>
          <Divider />
          <Title level={5}>Change Status</Title>
          <Space>
            {allowedTransitions.map((s) => (
              <Button
                key={s}
                type={s === 'Cancelled' ? 'default' : 'primary'}
                danger={s === 'Cancelled'}
                loading={isUpdating}
                onClick={() => changeStatus(s)}
              >
                {s}
              </Button>
            ))}
          </Space>
        </>
      )}
    </Show>
  );
}
