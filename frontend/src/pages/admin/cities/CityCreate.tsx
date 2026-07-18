import { Create, useForm } from '@refinedev/antd';
import { Form, Input, InputNumber } from 'antd';

export function CityCreate() {
  const { formProps, saveButtonProps } = useForm();
  return (
    <Create saveButtonProps={saveButtonProps}>
      <Form {...formProps} layout="vertical">
        <Form.Item label="Name" name="name" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item label="Country ID" name="countryId" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} min={1} />
        </Form.Item>
        <Form.Item label="Latitude" name="latitude" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} step={0.0001} />
        </Form.Item>
        <Form.Item label="Longitude" name="longitude" rules={[{ required: true }]}>
          <InputNumber style={{ width: '100%' }} step={0.0001} />
        </Form.Item>
        <Form.Item label="Image URL" name="image">
          <Input placeholder="https://..." />
        </Form.Item>
      </Form>
    </Create>
  );
}
