import { Edit, useForm } from '@refinedev/antd';
import { Form, Input, InputNumber } from 'antd';

export function RoomEdit() {
  const { formProps, saveButtonProps } = useForm();
  return (
    <Edit saveButtonProps={saveButtonProps}>
      <Form {...formProps} layout="vertical">
        <Form.Item label="Name" name="name" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item label="Hotel ID" name="hotelId" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} />
        </Form.Item>
        <Form.Item label="Room Type ID" name="roomTypeId" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} />
        </Form.Item>
        <Form.Item label="Area (m²)" name="area" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} step={0.5} />
        </Form.Item>
        <Form.Item label="Number of Rooms" name="numberOfRooms" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} />
        </Form.Item>
        <Form.Item label="Quantity" name="quantity" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} />
        </Form.Item>
      </Form>
    </Edit>
  );
}
