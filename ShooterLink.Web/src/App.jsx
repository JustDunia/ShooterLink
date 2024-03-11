import { Routes, Route } from 'react-router-dom'
import Login from './pages/Login'
import { CssBaseline, Container } from '@mui/material'
import { ThemeProvider } from '@mui/material/styles'
import Register from './pages/Register'
import Home from './pages/Home'
import { darkTheme } from './layout/theme'

export default function App() {
	return (
		<Container>
			<ThemeProvider theme={darkTheme}>
				<CssBaseline />
				<Routes>
					<Route path='/' element={<Home />} />
					<Route path='/login' element={<Login />} />
					<Route path='/register' element={<Register />} />
				</Routes>
			</ThemeProvider>
		</Container>
	)
}
