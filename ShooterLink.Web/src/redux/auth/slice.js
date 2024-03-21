import { createSlice } from '@reduxjs/toolkit'
import { register } from './operations'
import { logIn } from './operations'
import { logOut } from './operations'

const handlePending = state => {
	state.isLoading = true
}

const handleRejected = (state, action) => {
	state.isLoading = false
	state.error = action.payload
}

const isPendingAction = action => {
	return action.type.endsWith('/pending')
}

const isRejectAction = action => {
	return action.type.endsWith('/rejected')
}

const slice = createSlice({
	name: 'auth',
	initialState: {
		user: { firstName: null, lastName: null },
		token: null,
		isLoggedIn: false,
		isLoading: false,
		error: null,
	},
	extraReducers: builder => {
		builder
			.addCase(register.fulfilled, state => {
				state.user = null
				state.token = null
				state.isLoggedIn = false
				state.isLoading = false
				state.error = null
			})
			.addCase(logIn.fulfilled, (state, action) => {
				state.user = { firstName: action.payload.firstName, lastName: action.payload.lastName }
				state.token = action.payload.token
				state.isLoggedIn = true
				state.isLoading = false
				state.error = null
			})
			.addCase(logOut().type, (state, action) => {
				state.user = null
				state.token = null
				state.isLoggedIn = false
				state.isLoading = false
				state.error = null
			})
			.addMatcher(isPendingAction, handlePending)
			.addMatcher(isRejectAction, handleRejected)
	},
})

export const authReducer = slice.reducer
