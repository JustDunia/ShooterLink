import * as React from 'react'
import Avatar from '@mui/material/Avatar'
import Button from '@mui/material/Button'
import TextField from '@mui/material/TextField'
import Link from '@mui/material/Link'
import Grid from '@mui/material/Grid'
import Box from '@mui/material/Box'
import LockOutlinedIcon from '@mui/icons-material/LockOutlined'
import Typography from '@mui/material/Typography'
import Container from '@mui/material/Container'
import axios from 'axios'
import { Link as RouterLink } from 'react-router-dom'

export default function Login() {
	const handleSubmit = async event => {
		event.preventDefault()
		const data = new FormData(event.currentTarget)
		const userData = {
			email: data.get('email'),
			password: data.get('password'),
		}
		const response = await axios.post('/api/auth/login', userData)
	}

	return (
		<Container component='main' maxWidth='xs'>
			<Box
				sx={{
					marginTop: 8,
					display: 'flex',
					flexDirection: 'column',
					alignItems: 'center',
				}}
			>
				<Avatar sx={{ m: 1, bgcolor: 'primary.main' }}>
					<LockOutlinedIcon />
				</Avatar>
				<Typography component='h1' variant='h5'>
					Sign In
				</Typography>
				<Box component='form' onSubmit={handleSubmit} sx={{ mt: 1 }}>
					<TextField
						margin='normal'
						required
						fullWidth
						id='email'
						label='Email'
						name='email'
						autoComplete='email'
						autoFocus
					/>
					<TextField
						margin='normal'
						required
						fullWidth
						name='password'
						label='Hasło'
						type='password'
						id='password'
						autoComplete='current-password'
					/>
					{/* <FormControlLabel
						control={<Checkbox value='remember' color='primary' />}
						label='Zapamiętaj'
					/> */}
					<Button type='submit' fullWidth variant='contained' sx={{ mt: 3, mb: 2 }}>
						Sign In
					</Button>
					<Grid container sx={{ textAlign: 'center' }}>
						<Grid item xs={12} sm={6}>
							<Link href='#' variant='body2'>
								Forgot password
							</Link>
						</Grid>
						<Grid item xs={12} sm={6}>
							<Link component={RouterLink} to='/register' variant='body2'>
								Create account
							</Link>
						</Grid>
					</Grid>
				</Box>
			</Box>
		</Container>
	)
}
