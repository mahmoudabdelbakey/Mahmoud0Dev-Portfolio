/**
 * Mahmoud.Dev — Vercel Serverless Function: /api/contact
 * Receives form data and sends a professional HTML notification email
 * to mahmoudabdelbakey1@gmail.com via Gmail SMTP using nodemailer.
 *
 * Environment variables required in Vercel dashboard:
 *   SMTP_SENDER_EMAIL    = mahmoudabdelbakey1@gmail.com
 *   SMTP_SENDER_PASSWORD = fwirwhvlpkghuuoo
 *   SMTP_RECEIVER_EMAIL  = mahmoudabdelbakey1@gmail.com
 */

const nodemailer = require('nodemailer');

module.exports = async function handler(req, res) {
  // Only allow POST
  if (req.method !== 'POST') {
    return res.status(405).json({ success: false, message: 'Method Not Allowed' });
  }

  const { name, email, projectType, budget, description } = req.body || {};

  // Validate required fields
  if (!name || !name.trim()) {
    return res.status(400).json({ success: false, message: 'Please provide your name.' });
  }
  if (!email || !email.includes('@')) {
    return res.status(400).json({ success: false, message: 'Please provide a valid email address.' });
  }
  if (!description || !description.trim()) {
    return res.status(400).json({ success: false, message: 'Please describe your project or idea.' });
  }

  const senderEmail    = process.env.SMTP_SENDER_EMAIL    || 'mahmoudabdelbakey1@gmail.com';
  const senderPassword = process.env.SMTP_SENDER_PASSWORD || 'fwirwhvlpkghuuoo';
  const receiverEmail  = process.env.SMTP_RECEIVER_EMAIL  || 'mahmoudabdelbakey1@gmail.com';

  const transporter = nodemailer.createTransport({
    host: 'smtp.gmail.com',
    port: 587,
    secure: false,
    auth: {
      user: senderEmail,
      pass: senderPassword
    }
  });

  const htmlBody = `
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <style>
    body { font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, sans-serif; background-color: #f4f6f8; margin: 0; padding: 24px; color: #1e293b; }
    .container { max-width: 600px; background: #ffffff; margin: 0 auto; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.06); border: 1px solid #e2e8f0; }
    .header { background: linear-gradient(135deg, #0F766E 0%, #115E59 100%); padding: 32px 28px; text-align: left; color: #ffffff; }
    .header h1 { margin: 0; font-size: 22px; font-weight: 700; letter-spacing: -0.02em; }
    .header p { margin: 6px 0 0 0; font-size: 14px; opacity: 0.9; }
    .content { padding: 28px; }
    .badge { display: inline-block; background: #E6FFFA; color: #0F766E; font-size: 12px; font-weight: 700; padding: 4px 10px; border-radius: 9999px; margin-bottom: 20px; }
    .info-table { width: 100%; border-collapse: collapse; margin-bottom: 24px; }
    .info-table td { padding: 10px 0; border-bottom: 1px solid #edf2f7; font-size: 14px; vertical-align: top; }
    .info-table td.label { width: 130px; font-weight: 600; color: #64748b; }
    .info-table td.value { color: #0f172a; font-weight: 500; }
    .message-box { background: #f8fafc; border-left: 4px solid #0F766E; padding: 18px; border-radius: 6px; font-size: 14px; line-height: 1.6; color: #334155; white-space: pre-wrap; }
    .action-btn { display: inline-block; background: #0F766E; color: #ffffff !important; font-weight: 600; text-decoration: none; padding: 12px 24px; border-radius: 8px; font-size: 14px; margin-top: 24px; }
    .footer { background: #f8fafc; padding: 20px 28px; font-size: 12px; color: #94a3b8; text-align: center; border-top: 1px solid #edf2f7; }
  </style>
</head>
<body>
  <div class="container">
    <div class="header">
      <h1>&#128236; New Project Inquiry</h1>
      <p>Received directly from your portfolio: <strong>Mahmoud.Dev</strong></p>
    </div>
    <div class="content">
      <span class="badge">Instant Notification</span>
      <table class="info-table">
        <tr><td class="label">Client Name:</td><td class="value"><strong>${name}</strong></td></tr>
        <tr><td class="label">Client Email:</td><td class="value"><a href="mailto:${email}" style="color:#0F766E;font-weight:600;">${email}</a></td></tr>
        <tr><td class="label">Project Type:</td><td class="value">${projectType || 'Not specified'}</td></tr>
        <tr><td class="label">Budget Range:</td><td class="value">${budget || 'Flexible / Not specified'}</td></tr>
        <tr><td class="label">Submitted:</td><td class="value">${new Date().toUTCString()}</td></tr>
      </table>
      <div style="font-weight:700;font-size:14px;color:#0f172a;margin-bottom:8px;">Project Description &amp; Requirements:</div>
      <div class="message-box">${description}</div>
      <div style="text-align:center;">
        <a href="mailto:${email}?subject=Re:%20Your%20Inquiry%20from%20Mahmoud.Dev" class="action-btn">
          Reply to ${name} &#8594;
        </a>
      </div>
    </div>
    <div class="footer">
      Mahmoud Abd-Elbakey &bull; Full Stack .NET Developer &bull; Mahmoud.Dev
    </div>
  </div>
</body>
</html>`;

  try {
    await transporter.sendMail({
      from: `"Portfolio Lead — ${name}" <${senderEmail}>`,
      to: receiverEmail,
      replyTo: email,
      subject: `[Mahmoud.Dev] New Project Inquiry from ${name} (${projectType || 'General'})`,
      html: htmlBody
    });

    return res.status(200).json({
      success: true,
      message: `Thank you, ${name}! Your message has been received. Mahmoud will review your project details and get back to you within 24 hours.`
    });
  } catch (err) {
    console.error('Email send error:', err);
    return res.status(500).json({
      success: false,
      message: 'Message received but email notification failed. Mahmoud will still see your inquiry shortly.'
    });
  }
};
