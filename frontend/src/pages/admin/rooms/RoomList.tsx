import { List, useTable, EditButton, DeleteButton } from '@refinedev/antd';
import { Table, Space } from 'antd';

export function RoomList() {
  const { tableProps } = useTable({ syncWithLocation: true });
  return (
    <List>
      <Table {...tableProps} rowKey="id">
        <Table.Column dataIndex="id" title="ID" width={80} />
        <Table.Column dataIndex="name" title="Name" />
        <Table.Column dataIndex="hotelId" title="Hotel ID" width={100} />
        <Table.Column dataIndex="area" title="Area m²" render={(v: number) => `${v} m²`} />
        <Table.Column dataIndex="numberOfRooms" title="Rooms" width={80} />
        <Table.Column dataIndex="quantity" title="Qty" width={80} />
        <Table.Column dataIndex="roomTypeId" title="Type ID" width={100} />
        <Table.Column
          title="Actions"
          render={(_: unknown, record: { id: number }) => (
            <Space>
              <EditButton hideText size="small" recordItemId={record.id} />
              <DeleteButton hideText size="small" recordItemId={record.id} />
            </Space>
          )}
        />
      </Table>
    </List>
  );
}
