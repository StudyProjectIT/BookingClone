import { List, useTable, EditButton, DeleteButton } from '@refinedev/antd';
import { Table, Space } from 'antd';

export function HotelList() {
  const { tableProps } = useTable({
    syncWithLocation: true,
    sorters: { mode: 'off' },
  });

  return (
    <List>
      <Table {...tableProps} rowKey="id">
        <Table.Column dataIndex="id" title="ID" width={80} sorter={(a: { id: number }, b: { id: number }) => a.id - b.id} />
        <Table.Column dataIndex="name" title="Name" sorter={(a: { name: string }, b: { name: string }) => a.name.localeCompare(b.name)} />
        <Table.Column dataIndex="description" title="Description" ellipsis />
        <Table.Column dataIndex="cityName" title="City" sorter={(a: { cityName: string }, b: { cityName: string }) => a.cityName.localeCompare(b.cityName)} />
        <Table.Column dataIndex="hotelCategoryName" title="Category" />
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
