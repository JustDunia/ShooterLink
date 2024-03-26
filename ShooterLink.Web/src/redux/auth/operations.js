import axios from 'axios'
import { createAsyncThunk } from '@reduxjs/toolkit'

const setAuthHeader = token => {
	axios.defaults.headers.common.Authorization = `Bearer ${token}`
}

const clearAuthHeader = () => {
	axios.defaults.headers.common.Authorization = ''
}

export const register = createAsyncThunk('auth/register', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('/api/auth/register', userData)
		return true
	} catch (e) {
		return thunkAPI.rejectWithValue(e.response.data.errors.generalErrors || e.message)
	}
})

export const logIn = createAsyncThunk('auth/login', async (userData, thunkAPI) => {
	try {
		const response = await axios.post('/api/auth/login', userData)
		setAuthHeader(response.data.token)
		return response.data
	} catch (e) {
		return thunkAPI.rejectWithValue(e.message)
	}
})

export const logOut = () => {
	clearAuthHeader()
	return { type: 'auth/logOut' }
}
