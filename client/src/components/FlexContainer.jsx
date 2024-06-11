import classNames from 'classnames'

const FlexContainer = ({ children, className }) => {
    return (
        <div  className={classNames("d-flex flex-wrap gap-5 pt-3 mb-5 justify-content-center", className)}>
            {children}
        </div>
    )
}

export default FlexContainer