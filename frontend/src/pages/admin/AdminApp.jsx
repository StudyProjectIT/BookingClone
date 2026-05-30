import { Refine, Authenticated } from '@refinedev/core';
import {
  ThemedLayout,
  useNotificationProvider,
  AuthPage,
  ErrorComponent,
} from '@refinedev/antd';
import routerProvider, {
  CatchAllNavigate,
  NavigateToResource,
} from '@refinedev/react-router';
import { App as AntdApp } from 'antd';
import { Routes, Route, Outlet } from 'react-router-dom';
import '@refinedev/antd/dist/reset.css';

import { dataProvider } from '@shared/api/refineDataProvider';
import { authProvider } from '@shared/api/refineAuthProvider';
import { HotelList } from './hotels/HotelList';
import { HotelCreate } from './hotels/HotelCreate';
import { HotelEdit } from './hotels/HotelEdit';
import { BookingList } from './bookings/BookingList';
import { BookingShow } from './bookings/BookingShow';

export function AdminApp() {
  return (
    <AntdApp>
      <Refine
        routerProvider={routerProvider}
        dataProvider={dataProvider}
        authProvider={authProvider}
        notificationProvider={useNotificationProvider}
        resources={[
          {
            name: 'hotels',
            list: '/admin/hotels',
            create: '/admin/hotels/create',
            edit: '/admin/hotels/edit/:id',
            meta: { label: 'Hotels' },
          },
          {
            name: 'bookings',
            list: '/admin/bookings',
            show: '/admin/bookings/show/:id',
            meta: { label: 'Bookings' },
          },
        ]}
        options={{ syncWithLocation: true, useNewQueryKeys: true }}
      >
        <Routes>
          <Route path="login" element={<AuthPage type="login" />} />

          <Route
            element={
              <Authenticated
                key="admin-auth"
                fallback={<CatchAllNavigate to="/admin/login" />}
              >
                <ThemedLayout>
                  <Outlet />
                </ThemedLayout>
              </Authenticated>
            }
          >
            <Route index element={<NavigateToResource resource="hotels" />} />
            <Route path="hotels">
              <Route index element={<HotelList />} />
              <Route path="create" element={<HotelCreate />} />
              <Route path="edit/:id" element={<HotelEdit />} />
            </Route>
            <Route path="bookings">
              <Route index element={<BookingList />} />
              <Route path="show/:id" element={<BookingShow />} />
            </Route>
            <Route path="*" element={<ErrorComponent />} />
          </Route>
        </Routes>
      </Refine>
    </AntdApp>
  );
}
