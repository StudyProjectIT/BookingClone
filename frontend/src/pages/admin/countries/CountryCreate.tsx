import { Create, useForm } from '@refinedev/antd';
import { Form, Input } from 'antd';

export function CountryCreate() {
  const { formProps, saveButtonProps } = useForm();
  return (
    <Create saveButtonProps={saveButtonProps}>
      <Form {...formProps} layout="vertical">
        <Form.Item label="Name" name="name" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item label="Flag URL" name="image">
          <Input placeholder="https://..." />
        </Form.Item>
      </Form>
    </Create>
  );
}
