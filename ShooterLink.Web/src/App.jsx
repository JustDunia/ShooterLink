import './App.css'
import { Routes, Route } from 'react-router-dom'
import Login from './Components/Login/Login'
import { CssBaseline } from '@mui/material'
import { ThemeProvider, createTheme } from '@mui/material/styles'

const darkTheme = createTheme({
	palette: {
		mode: 'dark',
	},
})

function App() {
	return (
		<div>
			<ThemeProvider theme={darkTheme}>
				<CssBaseline />
				<Routes>
					<Route path='/login' element={<Login />} />
				</Routes>
			</ThemeProvider>
		</div>
	)
}

export default App
