import { List, useTable, ShowButton } from '@refinedev/antd';
import { Table, Space } from 'antd';

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
          render={(v) => new Date(v).toLocaleDateString()}
        />
        <Table.Column
          dataIndex="checkOut"
          title="Check Out"
          render={(v) => new Date(v).toLocaleDateString()}
        />
        <Table.Column
          dataIndex="totalPrice"
          title="Total Price"
          render={(v) => `$${Number(v).toFixed(2)}`}
        />
        <Table.Column
          title="Actions"
          render={(_, record) => (
            <Space>
              <ShowButton hideText size="small" recordItemId={record.id} />
            </Space>
          )}
        />
      </Table>
    </List>
  );
}
