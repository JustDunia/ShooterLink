import Container from '@mui/material/Container'
import Box from '@mui/material/Box'
import Typography from '@mui/material/Typography'
import Link from '@mui/material/Link'
import { Link as RouterLink } from 'react-router-dom'
import DoneOutlineIcon from '@mui/icons-material/DoneOutline'
import Avatar from '@mui/material/Avatar'

export default function RegisteredInfo() {
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
					<DoneOutlineIcon />
				</Avatar>
				<Typography component='h1' variant='h5'>
					Registration successful
				</Typography>
				<Typography
					component='h2'
					variant='body1'
					sx={{
						paddingBlock: 3,
						textAlign: 'center',
					}}
				>
					Verification email has been sent to your email address.
				</Typography>
				<Link component={RouterLink} to='/login' variant='body2'>
					Sign in
				</Link>
			</Box>
		</Container>
	)
}
