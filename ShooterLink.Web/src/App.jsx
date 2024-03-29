import { Route, Routes } from "react-router-dom";
import Login from "./pages/Login";
import { CssBaseline } from "@mui/material";
import { ThemeProvider } from "@mui/material/styles";
import Register from "./pages/Register";
import AdminPanel from "./pages/AdminPanel";
import Home from "./pages/Home";
import { darkTheme } from "./layout/theme";
import SharedLayout from "./components/SharedLayout";
import PrivateRoute from "./components/PrivateRoute";
import RestrictedRoute from "./components/RestrictedRoute";

export default function App() {
  return (
    <>
      <ThemeProvider theme={darkTheme}>
        <CssBaseline />
        <Routes>
          <Route path="/" element={<SharedLayout />}>
            <Route index element={<PrivateRoute component={<Home />} />} />
            <Route
              path="/admin-panel"
              element={<PrivateRoute component={<AdminPanel />} />}
            />
          </Route>
          <Route
            path="/login"
            element={<RestrictedRoute component={<Login />} />}
          />
          <Route
            path="/register"
            element={<RestrictedRoute component={<Register />} />}
          />
        </Routes>
      </ThemeProvider>
    </>
  );
}
