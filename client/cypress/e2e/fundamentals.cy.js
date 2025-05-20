describe('Opening Test', () => {
  beforeEach(() => {
    cy.visit('/')
  })
  it('Contains correct header text', () => {
    cy.getDataTest('navbar-header').should('contain.text', 'Kaya')
  })
  it('Tests the login successfully', () => {
    cy.contains(/login/i)
    cy.getDataTest('email-form').click().type('jayme@chaka.comx')
    cy.getDataTest('login-button').click()
    cy.contains(/login failed/i)

    cy.getDataTest('password-form').click().type('password')
    cy.getDataTest('login-button').click()
  })
})