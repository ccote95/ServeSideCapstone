import classNames from 'classnames'

const PageContainer = ({ children, className }) => {
    return (
        <div  className={classNames("d-flex flex-wrap gap-5 pt-3 mb-5 justify-content-center", className)}>
            {children}
        </div>
    )
}

export default PageContainer