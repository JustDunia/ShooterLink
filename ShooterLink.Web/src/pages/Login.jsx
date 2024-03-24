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
import { useForm } from 'react-hook-form'

export default function Login() {
	const {
		register,
		handleSubmit,
		formState: { errors },
	} = useForm()

	const submit = async (data, e) => {
		e.preventDefault()
		const userData = {
			email: data.email,
			password: data.password,
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
				<Box component='form' onSubmit={handleSubmit(submit)} noValidate sx={{ mt: 3 }}>
					<Grid container spacing={2}>
						<Grid item xs={12}>
							<TextField
								fullWidth
								id='email'
								label='Email Address'
								name='email'
								autoComplete='email'
								{...register('email', {
									required: true,
									pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
								})}
								error={errors.email ? true : false}
								helperText={
									errors.email &&
									(errors.email.type === 'required'
										? 'Email name is required'
										: 'Provide valid email address')
								}
							/>
						</Grid>
						<Grid item xs={12}>
							<TextField
								fullWidth
								name='password'
								label='Password'
								type='password'
								id='password'
								{...register('password', { required: 'Password is required' })}
								error={errors.password ? true : false}
								helperText={errors.password && errors.password.message}
							/>
						</Grid>
					</Grid>
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
