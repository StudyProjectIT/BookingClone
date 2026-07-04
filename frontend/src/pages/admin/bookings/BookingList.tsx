import { List, useTable, ShowButton } from '@refinedev/antd';
import { Table, Space, Tag } from 'antd';
import type { BookingStatus } from '@shared/types';

const statusColor: Record<BookingStatus, string> = {
  Pending: 'orange',
  Confirmed: 'green',
  Cancelled: 'red',
  Completed: 'blue',
};

export function BookingList() {
  const { tableProps } = useTable({ syncWithLocation: true });

  return (
    <List canCreate={false}>
      <Table {...tableProps} rowKey="id">
        <Table.Column dataIndex="id" title="ID" width={80} />
        <Table.Column dataIndex="hotelId" title="Hotel ID" />
        <Table.Column
          dataIndex="checkIn"
          title="Check In"
          render={(v: string) => new Date(v).toLocaleDateString()}
        />
        <Table.Column
          dataIndex="checkOut"
          title="Check Out"
          render={(v: string) => new Date(v).toLocaleDateString()}
        />
        <Table.Column
          dataIndex="totalPrice"
          title="Total Price"
          render={(v: number) => `$${v.toFixed(2)}`}
        />
        <Table.Column
          dataIndex="status"
          title="Status"
          render={(v: BookingStatus) => <Tag color={statusColor[v]}>{v}</Tag>}
        />
        <Table.Column
          title="Actions"
          render={(_: unknown, record: { id: number }) => (
            <Space>
              <ShowButton hideText size="small" recordItemId={record.id} />
            </Space>
          )}
        />
      </Table>
    </List>
  );
}
