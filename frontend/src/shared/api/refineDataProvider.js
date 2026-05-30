import { httpClient } from './httpClient';

export const dataProvider = {
  getList: async ({ resource, pagination }) => {
    const { current = 1, pageSize = 10 } = pagination ?? {};
    const { data } = await httpClient.get(`/${resource}`, {
      params: { page: current, pageSize },
    });
    const items = Array.isArray(data) ? data : (data.items ?? []);
    const total = data.totalCount ?? items.length;
    return { data: items, total };
  },

  getOne: async ({ resource, id }) => {
    const { data } = await httpClient.get(`/${resource}/${id}`);
    return { data };
  },

  create: async ({ resource, variables }) => {
    const { data } = await httpClient.post(`/${resource}`, variables);
    return { data };
  },

  update: async ({ resource, id, variables }) => {
    await httpClient.put(`/${resource}/${id}`, variables);
    return { data: { id, ...variables } };
  },

  deleteOne: async ({ resource, id }) => {
    await httpClient.delete(`/${resource}/${id}`);
    return { data: { id } };
  },

  getApiUrl: () => httpClient.defaults.baseURL ?? '',
};
