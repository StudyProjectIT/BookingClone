import { List, useTable, EditButton, DeleteButton } from '@refinedev/antd';
import { Table, Space } from 'antd';

export function CategoryList() {
  const { tableProps } = useTable({ syncWithLocation: true });
  return (
    <List>
      <Table {...tableProps} rowKey="id">
        <Table.Column dataIndex="id" title="ID" width={80} />
        <Table.Column dataIndex="name" title="Name" />
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
