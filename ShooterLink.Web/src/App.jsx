import { Routes, Route } from 'react-router-dom'
import Login from './pages/Login'
import { CssBaseline, Container } from '@mui/material'
import { ThemeProvider } from '@mui/material/styles'
import Register from './pages/Register'
import Home from './pages/Home'
import { darkTheme } from './layout/theme'
import SharedLayout from './components/SharedLayout'

export default function App() {
	return (
		<Container>
			<ThemeProvider theme={darkTheme}>
				<CssBaseline />
				<Routes>
					<Route path='/' element={<SharedLayout />}>
						<Route index element={<Home />} />
					</Route>
					<Route path='/login' element={<Login />} />
					<Route path='/register' element={<Register />} />
				</Routes>
			</ThemeProvider>
		</Container>
	)
}
