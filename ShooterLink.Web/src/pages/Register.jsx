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
import { Link as RouterLink } from 'react-router-dom'
import { useDispatch } from 'react-redux'
import { useForm } from 'react-hook-form'
import { useRef } from 'react'

export default function Register() {
	const dispatch = useDispatch()

	const {
		register,
		handleSubmit,
		watch,
		formState: { errors },
	} = useForm()

	const password = useRef({})
	password.current = watch('password', '')

	const submit = event => {
		event.preventDefault()
		const data = new FormData(event.currentTarget)
		const userData = {
			firstName: data.get('firstName'),
			lastName: data.get('lastName'),
			email: data.get('email'),
			password: data.get('password'),
		}
		dispatch(register(userData))
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
				{errors.firstName && <span>This field is required</span>}
				<Avatar sx={{ m: 1, bgcolor: 'primary.main' }}>
					<LockOutlinedIcon />
				</Avatar>
				<Typography component='h1' variant='h5'>
					Sign up
				</Typography>
				<Box component='form' onSubmit={handleSubmit(submit)} noValidate sx={{ mt: 3 }}>
					<Grid container spacing={2}>
						<Grid item xs={12} sm={6}>
							<TextField
								autoComplete='given-name'
								name='firstName'
								fullWidth
								id='firstName'
								label='First Name'
								autoFocus
								{...register('firstName', { required: 'First name is required', minLength: 2 })}
								error={errors.firstName ? true : false}
								helperText={
									errors.firstName &&
									(errors.firstName.type === 'required'
										? 'First name is required'
										: 'Min. length is 2 characters')
								}
							/>
						</Grid>
						<Grid item xs={12} sm={6}>
							<TextField
								fullWidth
								id='lastName'
								label='Last Name'
								name='lastName'
								autoComplete='family-name'
								{...register('lastName', { required: true, minLength: 2 })}
								error={errors.lastName ? true : false}
								helperText={
									errors.lastName &&
									(errors.lastName.type === 'required'
										? 'Last name is required'
										: 'Min. length is 2 characters')
								}
							/>
						</Grid>
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
								autoComplete='new-password'
								{...register('password', { required: true, minLength: 8 })}
								error={errors.password ? true : false}
								helperText={
									errors.password &&
									(errors.password.type === 'required'
										? 'Password is required'
										: 'Min. length is 8 characters')
								}
							/>
						</Grid>
						<Grid item xs={12}>
							<TextField
								fullWidth
								name='repeatPassword'
								label='Reapeat password'
								type='password'
								id='repeatPassword'
								{...register('repeatPassword', {
									required: 'Password confirmation is required',
									validate: fieldValue =>
										fieldValue === password.current || 'Provided passwords are different',
								})}
								error={errors.repeatPassword ? true : false}
								helperText={errors.repeatPassword && errors.repeatPassword.message}
							/>
						</Grid>
					</Grid>
					<Button type='submit' fullWidth variant='contained' sx={{ mt: 3, mb: 2 }}>
						Sign Up
					</Button>
					<Grid container justifyContent='flex-end'>
						<Grid item>
							<Link component={RouterLink} to='/login' variant='body2'>
								Sign in
							</Link>
						</Grid>
					</Grid>
				</Box>
			</Box>
		</Container>
	)
}
