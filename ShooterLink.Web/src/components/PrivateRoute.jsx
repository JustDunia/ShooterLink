import {useSelector} from 'react-redux'
import {Navigate} from 'react-router-dom'
import {selectIsLoading, selectIsLoggedIn} from '../redux/auth/selectors'

export default function PrivateRoute({component: Component, redirectTo = '/login'}) {
    const isLoggedIn = useSelector(selectIsLoggedIn)
    const isLoading = useSelector(selectIsLoading)
    const shouldRedirect = !isLoggedIn && !isLoading
    return shouldRedirect ? <Navigate to={redirectTo}/> : Component
}
