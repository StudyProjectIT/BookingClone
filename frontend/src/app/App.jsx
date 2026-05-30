import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import { AuthProvider } from '@features/auth';
import { Header } from '@widgets/header';
import { HomePage } from '@pages/home';
import { HotelsPage } from '@pages/hotels';
import { LoginPage } from '@pages/login';
import { RegisterPage } from '@pages/register';
import { AdminApp } from '@pages/admin';
import { Page404 } from '@pages/page404';
import { ProfilePage } from '@pages/profile';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/admin/*" element={<AdminApp />} />

        <Route
          path="*"
          element={
            <AuthProvider>
              <Header />
              <main>
                <Routes>
                  <Route path="/" element={<HomePage />} />
                  <Route path="/hotels" element={<HotelsPage />} />
                  <Route path="/login" element={<LoginPage />} />
                  <Route path="/register" element={<RegisterPage />} />
                  <Route path="/register" element={<RegisterPage />} />
                  <Route path="/profile" element={<ProfilePage />} />
                  <Route path="*" element={<Page404 />} />
                </Routes>
              </main>
            </AuthProvider>
          }
        />
      </Routes>
    </BrowserRouter>
  );
}
