import { Show, TextField, DateField, NumberField } from '@refinedev/antd';
import { useShow } from '@refinedev/core';
import { Typography } from 'antd';

const { Title } = Typography;

export function BookingShow() {
  const { query } = useShow();
  const { data, isLoading } = query;
  const record = data?.data;

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
      <NumberField
        value={record?.totalPrice}
        options={{ style: 'currency', currency: 'USD' }}
      />
    </Show>
  );
}
