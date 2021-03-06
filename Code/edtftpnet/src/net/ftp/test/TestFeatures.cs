// edtFTPnet
// 
// Copyright (C) 2004 Enterprise Distributed Technologies Ltd
// 
// www.enterprisedt.com
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// Bug fixes, suggestions and comments should posted on 
// http://www.enterprisedt.com/forums/index.php
// 
// Change Log:
// 
// $Log: TestFeatures.cs,v $
// Revision 1.4  2008-06-17 06:12:13  bruceb
// net cf changes
//
// Revision 1.3  2006/06/22 12:40:31  bruceb
// FTPException to FileTransferException
//
// Revision 1.2  2004/11/20 22:39:32  bruceb
// added to edtFTPnet test category
//
// Revision 1.1  2004/11/13 19:14:33  bruceb
// first cut of tests
//
//

using NUnit.Framework;
using FTPException = EnterpriseDT.Net.Ftp.FTPException;

namespace EnterpriseDT.Net.Ftp.Test
{
	
	/// <summary>  
	/// Test Features()
	/// </summary>
	/// <author>          Bruce Blackshaw
	/// </author>
	/// <version>         $Revision: 1.4 $
	/// </version>
	[TestFixture]
    [Category("edtFTPnet")]
    public class TestFeatures:FTPTestCase
	{
		/// <summary>  Get name of log file
		/// 
		/// </summary>
		/// <returns> name of file to log to
		/// </returns>
		override internal string LogName
		{
			get
			{
				return "TestFeatures.log";
			}			
		}
		
		/// <summary>Test Features() command</summary>
		[Test]
		public virtual void Features()
		{
			Connect();
			Login();
			
			// system
            FTPClient ftpClient = (FTPClient)ftp;
			try
			{
				string[] features = ftpClient.Features();
				for (int i = 0; i < features.Length; i++)
					log.Debug("Feature: " + features[i]);
			}
			catch (FTPException)
			{
				log.Warn("FEAT not implemented");
			}
			
			// complete
			ftp.Quit();
		}
	}
}
